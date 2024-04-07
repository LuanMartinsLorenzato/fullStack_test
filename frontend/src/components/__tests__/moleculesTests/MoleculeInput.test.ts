import { mount } from '@vue/test-utils'
import MoleculeInput from '../../molecules/MoleculeInput.vue'
import { describe, expect, test } from 'vitest'
import type { PropsMoleculeInput } from '@/utils/types'

describe(MoleculeInput, () => {
  const props: PropsMoleculeInput = {
    label: 'Username',
    inputType: 'text',
    mask: 'cpf',
    required: true
  }

  const wrapper = mount(MoleculeInput, {
    props
  })

  test('Renders label and input with correct attributes', () => {
    // Verifica se o componente está sendo renderizado
    expect(wrapper.exists()).toBe(true)

    // Verifica se a classe do container está presente
    expect(wrapper.classes()).toContain('ContainerInput')

    // Verifica se o label está correto
    const label = wrapper.find('label')
    expect(label.exists()).toBe(true)
    expect(label.attributes('for')).toBe(props.label)
  })

  test('Renders components is true', () => {
    // Verifica se o AtomSpan está presente
    const atomSpan = wrapper.findComponent({ name: 'AtomSpan' })
    expect(atomSpan.exists()).toBe(true)

    // Verifica se o AtomInput está presente
    const atomInput = wrapper.findComponent({ name: 'AtomInput' })
    expect(atomInput.exists()).toBe(true)
  })

  test('Emits "action" event with input value when action is triggered', async () => {
    // Simula uma entrada de valor no input
    await wrapper.findComponent({ name: 'AtomInput' }).vm.$emit('action', 'Test value')

    // Verifica se o evento "action" foi emitido com o valor correto
    const actionEvent = wrapper.emitted('action')
    expect(actionEvent).toBeTruthy()

    if (actionEvent) {
      expect(actionEvent[0][0]).toEqual(['Test value', props.label])
    }
  })
})
