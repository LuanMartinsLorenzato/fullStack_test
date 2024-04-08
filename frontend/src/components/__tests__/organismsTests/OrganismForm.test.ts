import { mount } from '@vue/test-utils'
import OrganismForm from '../../organisms/OrganismForm.vue'
import { describe, expect, test } from 'vitest'

describe(OrganismForm, () => {
  const wrapper = mount(OrganismForm, {
    slots: {
      inputs: `
            <input type="text" placeholder="Username" />
            <input type="password" placeholder="Password" />
          `,
      buttons: `
            <button type="submit">Submit</button>
            <button type="button">Cancel</button>
          `
    }
  })

  test('Renders form with inputs and buttons', () => {
    // Verifica se o componente está sendo renderizado
    expect(wrapper.exists()).toBe(true)

    // Verifica se o formulário está presente
    const form = wrapper.find('form')
    expect(form.exists()).toBe(true)

    // Verifica se os slots de entrada e botões estão presentes
    const inputsSlot = wrapper.find('.WrapInputs')
    expect(inputsSlot.exists()).toBe(true)
    expect(inputsSlot.html()).toContain('Username')
    expect(inputsSlot.html()).toContain('Password')

    const buttonsSlot = wrapper.find('.WrapButtons')
    expect(buttonsSlot.exists()).toBe(true)
    expect(buttonsSlot.html()).toContain('Submit')
    expect(buttonsSlot.html()).toContain('Cancel')
  })

  test('Emits "action" event when form is submitted', async () => {
    // Simula o envio do formulário
    await wrapper.find('form').trigger('submit')

    // Verifica se o evento "action" foi emitido
    expect(wrapper.emitted('action')).toBeTruthy()
  })
})
