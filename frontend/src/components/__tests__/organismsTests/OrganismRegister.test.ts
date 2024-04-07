import { mount } from '@vue/test-utils'
import OrganismRegister from '../../organisms/OrganismRegister.vue'
import { describe, expect, test } from 'vitest'

describe(OrganismRegister, () => {
  const wrapper = mount(OrganismRegister)

  test('Renders components', () => {
    // Verifica se o componente está sendo renderizado
    expect(wrapper.exists()).toBe(true)

    // Verifica se o componente OrganismForm está presente
    const organismForm = wrapper.findComponent({ name: 'OrganismForm' })
    expect(organismForm.exists()).toBe(true)

    // Verifica se os slots de entrada e botões estão presentes
    expect(organismForm.html()).contain('ContainerInput')

    // Verifica a quantidade de inputs
    expect(organismForm.findAllComponents({ name: 'MoleculeInput' }).length).toBe(3)

    // Verifica a quantidade de botões
    expect(organismForm.html()).contain('ContainerButton')
    expect(organismForm.findAllComponents({ name: 'MoleculeButton' }).length).toBe(2)
  })

  test('Emits "action" event when form is submitted', async () => {
    const formDataMock = {
      name: 'vitest',
      password: 'vitest'
    }

    wrapper.vm.formData = formDataMock;
    // Simula o envio do formulário
    await wrapper.find('form').trigger('submit')

    // Verifica se o evento "action" foi emitido
    expect(wrapper.emitted('action')).toBeTruthy()
  })
})
